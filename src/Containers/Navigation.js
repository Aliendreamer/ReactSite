import React,{Component} from 'react';
import {Navbar,NavbarBrand} from 'reactstrap';
import Button from './../Components/Button';
import ErrorHandler from './../helpers/ErrorHandler';
import axios from './../helpers/axios';
import {connect} from 'react-redux';
import classes from './../App.css';
class Navigation extends Component{



 render(){

    return(
            <Navbar className={classes.Navbar}> 
                <NavbarBrand href="/">academy</NavbarBrand>
                <Button label="courses"/>
                <Button label="lectors"/>
                <Button label="about"/>
                <Button label="logIn"/>
                <Button label="logout"/>
            </Navbar>
            

    )
 }

}

const mapStateToProps=state=>{
    return{
       
    }
}
const mapDispatchToProps=dispatch=>{
        return {
        }
}
export  default connect(mapStateToProps,mapDispatchToProps)(ErrorHandler(Navigation,axios));
