import React from 'react';
import {BrowserRouter as router, Routes, Route} from 'react-router-dom';
import Login from './Login';
import Registration from './Registration';
import Dashboard from './users/Dashboard';
import Orders from './users/Orders';
import Profile from './users/Profile';
import ProductDisplay from './users/ProductDisplay';
import Cart from './users/Cart';
import Product from './admin/Product';
import CustomerList from './admin/CustomerList';
import AdminOrders from './admin/AdminOrders';
import AdminDashboard from './admin/AdminDashboard';




export default function RouterPage(){
    return(
        <Router>
            <Routes>
                <Route path='/' element={<Login/>}/>
                <Route path='/Registration' element={<Registration/>}/>

                <Route path='/Dashboard' element={<Dashboard/>}/>
                <Route path='/Orders' element={<Orders/>}/>
                <Route path='/Profile' element={<Profile/>}/>
                <Route path='/ProductDisplay' element={<ProductDisplay/>}/>
                <Route path='/Cart' element={<Cart/>}/>

                <Route path='/Product' element={<Product/>}/>
                <Route path='/CustomerList' element={<CustomerList/>}/>
                <Route path='/AdminOrders' element={<AdminOrders/>}/>
                <Route path='/AdminDashboard' element={<AdminDashboard/>}/>
                CustomerList
            </Routes>
        </Router>
    )
}