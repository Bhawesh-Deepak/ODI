import './App.css';
import React, { useState, useEfffect } from 'react';
import Header from './Components/Layout/Header';
import Sidebar from './Components/Layout/SideBar';
import Dashboard from './Components/Dashboard/Dashboard';
import Footer from './Components/Layout/Footer';
import Login from './Components/UserManagement/Login';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Register from './Components/UserManagement/Register';

function App() {
  const [isLoggged, setIsLogged] = useState(window.localStorage.getItem("isLogged"));
  const [isRegister, setisRegister] = useState(false);

  // useEfffect(() => {
  //   setIsLogged(window.localStorage.getItem("isLogged"))
  // }, [])

  return (
    <div className="App">
      {isLoggged ? (<>
        <Router>
          <Header></Header>
          <Sidebar></Sidebar>
          <Routes>
            <Route exact path='/Dashboard' element={<Dashboard />}></Route>
          </Routes>
        </Router>

        <Footer></Footer></>) : isRegister ? (<Register register={setisRegister} />) : (<Login register={setisRegister}></Login>)}


    </div>
  );
}

export default App;
