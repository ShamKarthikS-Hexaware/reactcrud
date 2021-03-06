const {
    render,
    screen,
    fireEvent,
    within,
    waitFor,
    getByRole,
    act,
    cleanup,
} = require('@testing-library/react')
import '@testing-library/jest-dom/extend-expect'
import { Provider } from 'react-redux'
import store from 'app/redux/store'
import { BrowserRouter as Router } from 'react-router-dom'
import { SettingsProvider } from 'app/contexts/SettingsContext'
import { MatxTheme } from 'app/components'
import axios from '../../../../axios'
import MockAdapter from 'axios-mock-adapter'
import AddPlayer from '../AddPlayer'

beforeEach(() => {
    const endPoint = 'player'
    const getStudentListResponse = [
        {
            id: 1,
            name: 'name',
        },
    ]
    const mock = new MockAdapter(axios)
    mock.onGet(`/${endPoint}`).reply(200, getStudentListResponse)
    render(
        <Provider store={store}>
            <SettingsProvider>
                <MatxTheme>
                    <Router>
                        <AddPlayer />
                    </Router>
                </MatxTheme>
            </SettingsProvider>
        </Provider>
    )
})

const clickAndWait = async (element) => {
    await act(async () => {
        fireEvent.click(element)
    })

    await act(async () => {
        jest.runOnlyPendingTimers()
    })
}

afterEach(cleanup)

describe('testing view PlayerAdd Component', () => {
    test('should render AddPlayer and to display Add Form title', async () => {
        const headingNote = screen.getByText(/Add Form/i)
        expect(headingNote).toBeInTheDocument()
    })

    test('should have all input fields present in the add form', async () => {
        const addPlayerButtonElement = screen.getByRole('button', {
            name: /Add/i,
        })

        const nameElement = screen.getByLabelText(/Name/i)

        expect(addPlayerButtonElement).toBeInTheDocument()

        expect(nameElement).toBeInTheDocument()
    })

    test('should be able to give inputs to all fields of Player add form', async () => {
        const nameElement = screen.getByLabelText(/Name/i)

        fireEvent.change(nameElement, { target: { value: 'name' } })
    })

    test('should return error message when add Player button is clicked on invalid form', async () => {
        jest.useFakeTimers()
        const addPlayerButtonElement = screen.getByRole('button', {
            name: /Add/i,
        })

        await clickAndWait(addPlayerButtonElement)

        let errorList = await screen.findAllByText('this field is required')
        expect(errorList).toHaveLength(1)
    })
})
