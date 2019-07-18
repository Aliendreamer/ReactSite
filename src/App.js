import React from 'react';
import './App.css';
import Navigation from './Containers/Navigation';
import MainBody from './Containers/MainBody';
import Footer from './Containers/Footer';
import {Route,Switch} from 'react-router-dom';
import LoginForm from './Components/LoginForm';

function App() {
  debugger
  return (
    <div>
      <Navigation/>
      <Switch>
      <Route path="/" component={MainBody}/>
      <Route   path="/login" component={LoginForm}/>
     </Switch>
      <Footer/>
    </div>
  );
}

export default App;
