import React from 'react'
import { Route, Routes } from 'react-router-dom'
import Layout from './components/Layout'
import Home from './Pages/Home'
import SignUp from './Pages/SignUp'
import Login from './Pages/Login'
import AddBookmark from './Pages/AddBookmark'
import MyBookmarks from './Pages/MyBookmarks'
import Logout from './Pages/Logout'
import { AuthenticationContextComponent } from './AuthenticationContext'



const App = () => {
    return (
        <AuthenticationContextComponent>
            <Layout>
                <Routes>
                    <Route path='/' element={<Home />} />
                    <Route path='/signup' element={<SignUp />} />
                    <Route path='/login' element={<Login />} />
                    <Route path='/logout' element={<Logout/>} />
                    <Route path='/addbookmark' element={<AddBookmark />} />
                    <Route path='/mybookmarks' element={<MyBookmarks />} />
                </Routes>
            </Layout>
        </AuthenticationContextComponent>
    );
}

export default App;