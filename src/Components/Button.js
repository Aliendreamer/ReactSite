import React from 'react';
import {Button} from 'reactstrap';

const button=(props)=>(

    <Button onClick={props.clicked} className={props.buttonStyle} >{props.label}</Button>
)

export default button;