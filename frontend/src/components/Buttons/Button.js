import React from 'react';
import styles from '../../scss/components/barrel_components.module.scss';

const {loginButtonOutlined} = styles


export default function Button(props) {
  return (
    <button type={props.type} className={loginButtonOutlined}>{props.value}</button>
  )
}
