import React from 'react';
import {Button} from 'reactstrap';
import classes from './../App.module.css';
const button=(props)=>(

    <Button onClick={props.clicked} className={props.NavigationItem} >{props.label}</Button>
)

export default button;