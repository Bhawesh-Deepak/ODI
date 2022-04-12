import './App.css';
import React, { useState, useEfffect } from 'react';
import Header from './Components/Layout/Header';
import Sidebar from './Components/Layout/SideBar';
import Dashboard from './Components/Dashboard/Dashboard';
import Footer from './Components/Layout/Footer';
import Login from './Components/UserManagement/Login';

function App() {
  const [isLoggged, setIsLogged] = useState(false);
  return (
    <div className="App">
      {isLoggged ? (<> <Header></Header>
        <Sidebar></Sidebar>
        <Dashboard></Dashboard>
        <Footer></Footer></>) : (<Login></Login>)}


    </div>
  );
}

export default App;
