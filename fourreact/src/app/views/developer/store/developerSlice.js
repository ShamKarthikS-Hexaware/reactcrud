import { createSlice } from '@reduxjs/toolkit'
import { fetchDeveloper } from './developer.action'
import { addDeveloper } from './developer.action'
import { editDeveloper } from './developer.action'
import { deleteDeveloper } from './developer.action'

const fetchDeveloperExtraReducer = {
    [fetchDeveloper.pending]: (state, action) => {
        state.loading = true
    },
    [fetchDeveloper.fulfilled]: (state, action) => {
        state.entities = [...action.payload]
        state.loading = false
    },
    [fetchDeveloper.rejected]: (state, action) => {
        state.loading = false
    },
}

const addDeveloperExtraReducer = {
    [addDeveloper.pending]: (state, action) => {
        state.loading = true
    },
    [addDeveloper.fulfilled]: (state, action) => {
        state.entities.push(action.payload)
        state.loading = false
    },
    [addDeveloper.rejected]: (state, action) => {
        state.loading = false
    },
}

const editDeveloperExtraReducer = {
    [editDeveloper.pending]: (state, action) => {
        state.loading = true
    },
    [editDeveloper.fulfilled]: (state, action) => {
        const { id, name } = action.payload
        const existingDeveloper = state.entities.find(
            (developer) => developer.id.toString() === id.toString()
        )
        if (existingDeveloper) {
            existingDeveloper.name = name
        }
        state.loading = false
    },
    [editDeveloper.rejected]: (state, action) => {
        state.loading = false
    },
}

const deleteDeveloperExtraReducer = {
    [deleteDeveloper.pending]: (state, action) => {
        state.loading = true
    },
    [deleteDeveloper.fulfilled]: (state, action) => {
        const id = action.payload
        const existingDeveloper = state.entities.find(
            (developer) => developer.id.toString() === id.toString()
        )
        if (existingDeveloper) {
            state.entities = state.entities.filter(
                (developer) => developer.id !== id
            )
        }
        state.loading = false
    },
    [deleteDeveloper.rejected]: (state, action) => {
        state.loading = false
    },
}
const developerSlice = createSlice({
    name: 'developer',
    initialState: {
        entities: [],
        loading: false,
    },
    reducers: {
        developerAdded(state, action) {
            state.entities.push(action.payload)
        },
        developerUpdated(state, action) {
            const { id, name } = action.payload
            const existingDeveloper = state.entities.find(
                (developer) => developer.id.toString() === id.toString()
            )
            if (existingDeveloper) {
                existingDeveloper.name = name
            }
        },
        developerDeleted(state, action) {
            const { id } = action.payload
            const existingDeveloper = state.entities.find(
                (developer) => developer.id.toString() === id.toString()
            )
            if (existingDeveloper) {
                state.entities = state.entities.filter(
                    (developer) => developer.id !== id
                )
            }
        },
    },
    extraReducers: {
        ...fetchDeveloperExtraReducer,
        ...addDeveloperExtraReducer,
        ...editDeveloperExtraReducer,
        ...deleteDeveloperExtraReducer,
    },
})

export const { developerAdded, developerUpdated, developerDeleted } =
    developerSlice.actions

export default developerSlice.reducer
