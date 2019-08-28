import React, { Component } from "react";
import {connect} from 'react-redux';
import classes from './../App.module.css';
import Spinner from './Spinner';
import { NavLink} from "react-router-dom";
import {withFormik} from 'formik';
import Yup from 'yup';
class Register extends Component{




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
            <p class="message">you have an account? <NavLink to="/login">login now</NavLink></p>
            </form>
            </div>        
        </div>
        )
    }
}

const mapPropsToState=state=>{

    return{
       
    }
}
const mapDispatchToProps=dispatch=>{

    return {
       
    }
}

export default connect(mapPropsToState,mapDispatchToProps)(withFormik({
    mapPropsToValues(){
        return {
       
        }
    }, 
    // validationSchema:Yup.object().shape({
    //     // username:Yup.string().required(),
    //     // password:Yup.string()
    //     // password:Yup.string().min(8).required()
    // }),
    handleSubmit(values,{props,resetForm}){
        const{username,password}={...values} 
        props.onSubmit(username,password);
        resetForm()
    }
})(Register));