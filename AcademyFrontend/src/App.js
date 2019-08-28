import React from 'react';
import './App.module.css';
import Navigation from './Containers/Navigation';
import MainBody from './Containers/MainBody';
import Footer from './Containers/Footer';
import {Route,Switch} from 'react-router-dom';
import LoginForm from './Components/LoginForm';
import RegisterForm from './Components/RegisterForm';

function App() {
  return (
    <div>
      <Navigation/>
      <Switch>
      <Route  exact path="/login" component={LoginForm}/>
      <Route  exact path="/register" component={RegisterForm}/>
      <Route path="/" component={MainBody}/>
      
     </Switch>
      <Footer/>
    </div>
  );
}

export default App;
