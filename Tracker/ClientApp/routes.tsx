import * as React from 'react'
import { Route, RouteComponentProps } from 'react-router-dom'
import { Layout } from './components/Layout'

import Counter from './components/Counter'
import FetchData from './components/FetchData'
import Home from './components/Home'

export const routes = <Layout>
	<Route exact path='/' component={Home} />
	<Route path='/counter' component={Counter as any} />
	<Route path='/fetchdata/:startDateIndex?' component={FetchData as any} />
</Layout>
