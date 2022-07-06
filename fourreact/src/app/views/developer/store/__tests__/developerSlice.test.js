import store from 'app/redux/store'
import {
    developerAdded,
    developerDeleted,
    developerUpdated,
} from '../developerSlice'

describe('testing developer redux store reducers', () => {
    test('add developer to store test', () => {
        let state = store.getState().developer
        expect(state.entities).toHaveLength(0)
        const initialInput = {
            id: 1,
            name: 'name',
        }
        store.dispatch(developerAdded(initialInput))
        state = store.getState().developer
        expect(state.entities).toHaveLength(1)
    })

    test('update developer from store should change the length of the entities array in redux store', () => {
        const initialInput = {
            id: 2,
            name: 'name',
        }
        store.dispatch(developerAdded(initialInput))
        let state = store.getState().developer
        expect(state.entities).toHaveLength(2)

        const updatedInput = {
            id: initialInput.id,
            name: 'name1',
        }
        store.dispatch(developerUpdated(updatedInput))
        state = store.getState().developer
        let changedDeveloper = state.entities.find((p) => p.id === 2)
        expect(changedDeveloper).toStrictEqual(updatedInput)
    })

    test('delete developer from store should reduce the length of the entities array in redux store', () => {
        const initialInput = {
            id: 3,
            name: 'name',
        }
        store.dispatch(developerAdded(initialInput))
        let state = store.getState().developer
        expect(state.entities).toHaveLength(3)

        store.dispatch(
            developerDeleted({
                id: initialInput.id,
            })
        )
        state = store.getState().developer
        expect(state.entities).toHaveLength(2)
    })
})
