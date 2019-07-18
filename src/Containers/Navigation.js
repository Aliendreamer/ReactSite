import React,{Component} from 'react';
import {Navbar,NavItem,NavbarBrand} from 'reactstrap';
import Button from './../Components/Button';
import ErrorHandler from './../helpers/ErrorHandler';
import axios from './../helpers/axios';
import {connect} from 'react-redux';
import classes from './../App.css';
import {NavLink} from 'react-router-dom';

class Navigation extends Component{



 render(){

        let conditionalNavItems=[];
        debugger;
        if(this.props.isLogged){
            conditionalNavItems.push(<NavItem><Button label="logout"/></NavItem>);
            conditionalNavItems.push(<NavItem><Button label="profile"/></NavItem>);
        }else{
            conditionalNavItems.push(<NavItem><NavLink to="/login" >Login</NavLink></NavItem>)
        }
    return(
            <Navbar className={classes.Navbar}> 
                <NavbarBrand href="/">academy</NavbarBrand>
                <NavItem>
                <Button label="courses"/>
                </NavItem>
                <NavItem>
                <Button label="lectors"/>
                </NavItem>
                <NavItem>
                <Button label="about"/>
                </NavItem>
                {conditionalNavItems}
            </Navbar>
            

    )
 }

}

const mapStateToProps=state=>{
    return{
       isLogged:state.authReducer.isLogged,
       isLoading:state.authReducer.loading
    }
}
const mapDispatchToProps=dispatch=>{
        return {
        }
}
export  default connect(mapStateToProps,mapDispatchToProps)(ErrorHandler(Navigation,axios));
