import * as actionTypes from './actionTypes';
import axios from './../helpers/axios';

export const authStart=()=>{
    return {
        type:actionTypes.START_AUTH_REQUEST,
        isLoading:true
    }
}

export const authSuccess=(username,id,authToken)=>{
    return{
        type:actionTypes.AUTH_REQEST_SUCCESS,
        username:username,
        id:id,
        authToken:authToken
    }
  
}

export const authFail=(error)=>{
        return{
            type:actionTypes.AUTH_REQUEST_FAILURE,
            authError:error,
            isLoading:false
        }
}

export const auth=(username,password)=>{
    return dispatch =>{
        dispatch(authStart());        
        
        const authData={
            username,
            password
        }
        
        const loginInfo =`Basic ${btoa(username+ ":" +password)}`

        const options={ 
             "headers":{
            "Authorization":loginInfo,
            "X-Kinvey-API-Version":3
        }
    }
       debugger;
        const url=`https://baas.kinvey.com/user/05f178f4b61343149f62073f0b3bb0b8/login`;
        axios.post(url,authData,options)
        .then(response=>{

            debugger;
            const data={
                "username":response.data.username,
                "id":response.data._id,
                "authToken":response.data._kmd.authtoken
            }
            dispatch(authSuccess(data.username,data.id,data.authToken))
          
        }).catch(err=>{
            console.log(err)
            debugger;
            dispatch(authFail(err.message))
        })

    }
}

