import React from 'react';
import * as actionTypes from './actionTypes';

const initialState={
    loading:false,
    isLogged:false
}
 const authReducer=(state=initialState,action)=>{


    switch(action.type){
        case actionTypes.START_AUTH_REQUEST:
           
            return{
                ...state,
                loading:false,
              
            }
            default:
                return state
        }
}

export default authReducer;