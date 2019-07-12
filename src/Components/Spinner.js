import Spinner from 'react-bootstrap/Spinner'
import React from 'react';

const spinner=(props)=>{
    let spinnerEl=null;

    if(props.loading){
        spinnerEl=
        <Spinner animation="grow" role="status" size="sm" >
          <span className="sr-only">Loading...</span>
        </Spinner>
        
    }
    return spinnerEl;
}

export default spinner