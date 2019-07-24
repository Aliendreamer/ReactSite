import * as actionTypes from './actionTypes';

const initialState={
    loading:false,
    isLogged:false,
    error:null,
    username:"",
    userId:"",
    authToken:""
}
 const authReducer=(state=initialState,action)=>{


    switch(action.type){

        case actionTypes.START_AUTH_REQUEST:
            return{
                ...state,
                loading:action.isLoading,
              
            }
        case actionTypes.AUTH__REQUEST_SEND_AUTH_INFO:
           return{
               ...state
           }
        case actionTypes.AUTH_REQEST_SUCCESS:
            return{
                    ...state,
                    loading:false,
                    isLogged:true,
                    username:action.username,
                    userId:action.id,
                    authToken:action.authToken
            }

            default:
                return state
        }
}

export default authReducer;