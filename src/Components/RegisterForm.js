import React, { Component } from "react";
import {connect} from 'react-redux';
import classes from './../App.module.css';
import Spinner from './Spinner';
import {withFormik} from 'formik';
import Yup from 'yup';
class Login extends Component{




    render(){
        const values={...this.props}
        return(
         <div className={classes.LoginPage }>
            <div class="form">
            <form class="register-form">
            <input type="text" placeholder="name"/>
            <input type="password" placeholder="password"/>
            <input type="text" placeholder="email address"/>
            <button>create</button>
            <p class="message">Имаш регистрация? <a href="#">логни  се</a></p>
            </form>
            </div>        
        </div>
        )
    }
}

const mapDispatchToProps=dispatch=>{

    return {
       
    }
}

export default connect(null,mapDispatchToProps)(withFormik({
    mapPropsToValues(){
        return {
        email:"testText"
        }
    }
})(Login));