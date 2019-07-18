import React, { Component } from "react";
import {connect} from 'react-redux';

class Login extends Component{




    render(){

        return(
            <div>
                login form
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

export default connect(mapPropsToState,mapDispatchToProps)(Login);