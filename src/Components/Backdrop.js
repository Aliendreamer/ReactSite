import React from 'react';
import classes from './../App.module.css';


const backdrop=(props)=>{

  return(
    props.show? 
    <div className={classes.Backdrop}
    onClick={props.close}>
    </div>:null
  )
}


export default backdrop;