const { render, screen, cleanup } = require('@testing-library/react')
import '@testing-library/jest-dom/extend-expect'
import { Provider } from 'react-redux'
import store from 'app/redux/store'
import { BrowserRouter as Router } from 'react-router-dom'
import { SettingsProvider } from 'app/contexts/SettingsContext'
import { MatxTheme } from 'app/components'
import DeveloperList from '../DeveloperList'
import axios from '../../../../axios'
import MockAdapter from 'axios-mock-adapter'

afterEach(cleanup)

test('should render Developer rows when api response has data', async () => {
    const endPoint = 'developer'
    const getDeveloperListResponse = [
        {
            id: 1,
            name: 'name1',
        },
    ]
    const mock = new MockAdapter(axios)
    mock.onGet(`/${endPoint}`).reply(200, getDeveloperListResponse)
    render(
        <Provider store={store}>
            <SettingsProvider>
                <MatxTheme>
                    <Router>
                        <DeveloperList />
                    </Router>
                </MatxTheme>
            </SettingsProvider>
        </Provider>
    )
    const developerNameCell = await screen.findByText(/name1/i)

    expect(developerNameCell).toHaveTextContent(/name1/i)
    mock.reset()
})
