import React,{Component} from 'react';
import {Navbar,NavItem,NavbarBrand} from 'reactstrap';
import Button from './../Components/Button';
import ErrorHandler from './../helpers/ErrorHandler';
import axios from './../helpers/axios';
import {connect} from 'react-redux';
import classes from './../App.module.css';
import {NavLink} from 'react-router-dom';

class Navigation extends Component{



 render(){

        let conditionalNavItems=[];
        if(this.props.isLogged){
            conditionalNavItems.push(<NavItem><Button label="logout"/></NavItem>);
            conditionalNavItems.push(<NavItem><Button label="profile"/></NavItem>);
        }else{
            conditionalNavItems.push(<NavItem>
                                        <NavLink 
                                         to="/login" >Login
                                        </NavLink>
                                        </NavItem>)
        }
    return(
            <Navbar className={classes.Navbar}> 
                <NavbarBrand href="/">academy</NavbarBrand>
                <NavItem className={classes.NavigationItem}>
                <NavLink to ="">courses</NavLink>
                </NavItem>
                <NavItem>
                <NavLink to="">lectors</NavLink>
                </NavItem>
                <NavItem>
                <NavLink to="" >about</NavLink>
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
