import React, { Component } from "react";
import {connect} from 'react-redux';
import classes from './../App.module.css';
import Spinner from './Spinner';
import {withFormik,Form,Field} from 'formik';
import * as Yup from 'yup';
import { NavLink} from "react-router-dom";
import {Redirect} from "react-router";
import *as actions from './../Reducers/authActions';
class Login extends Component{
   



    render(){
        let redirect= this.props.isLogged?<Redirect to="/"/>:null;
        const {errors,touched}={...this.props}

        return(

         <div className={classes.Fragment}>
          {redirect}   
         <Spinner loading={this.props.isLoading}/> 
         <div className={classes.LoginPage }>
            <Form class="login-form" >
             <div>
                 { touched.email ?<p>{errors.username}</p>:null}   
            <Field type="text" name="username"placeholder="username"/>
            </div>
            <div>
            {touched.password?<p>{errors.password}</p>:null}   
            <Field type="password" name="password" placeholder="password"/>
            </div>
            <button disabled={this.props.isLoading}>login</button>
            <p class="message">Not registered? <NavLink to="/register">Create an account</NavLink></p>
            </Form>       
        </div>
        </div>
        )
    }
}
const mapPropsToState=state=>{

    return{
        isLoading:state.authReducer.isLoading,
        isLogged:state.authReducer.isLogged
    }
}
const mapDispatchToProps=dispatch=>{

    return {
       onSubmit:(username,password)=>(dispatch(actions.auth(username,password)))
    }
}

export default connect(mapPropsToState,mapDispatchToProps)(withFormik({
    mapPropsToValues(){
        return {
        username:'',
        password:''
        }
    }, 
    validationSchema:Yup.object().shape({
        username:Yup.string().required(),
        password:Yup.string()
        // password:Yup.string().min(8).required()
    }),
    handleSubmit(values,{props,resetForm}){
        const{username,password}={...values} 
        props.onSubmit(username,password);
        resetForm()
    }
})(Login));