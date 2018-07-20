import * as React from 'react'
import { Route } from 'react-router-dom'
import { Layout } from './components/Layout'

import Counter from './components/Counter'
import FetchData from './components/FetchData'
import Home from './components/Home'

export const routes = <Layout>
	<Route exact path='/' component={Home} />
	<Route path='/counter' component={Counter} />
	<Route path='/fetchdata/:startDateIndex?' component={FetchData} />
</Layout>
