import React from 'react';
import './App.css';
import Navigation from './Containers/Navigation';
import MainBody from './Containers/MainBody';
import Footer from './Containers/Footer';
import {Route,Switch} from 'react-router-dom';

function App() {
  return (
    <div>
      <Navigation/>
      <Switch>
      <Route path="/" component={MainBody}/>
     </Switch>
      <Footer/>
    </div>
  );
}

export default App;
