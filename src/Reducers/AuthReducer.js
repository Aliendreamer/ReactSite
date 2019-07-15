import React from 'react';
import * as actionTypes from './actionTypes';

const initialState={
    loading:false,
}
 const authReducer=(state=initialState,action)=>{


    switch(action.type){
        case actionTypes.PURCHASE_BURGER_SUCCESS:
           
            return{
                ...state,
                loading:false,
              
            }
            default:
                return state
        }
}

export default authReducer;