import React from 'react';
import Image from 'next/image';
import GoogleIcon from '../../../public/google.png';
import styles from '../../scss/components/barrel_components.module.scss';


const {fastSignInButton} = styles;

export default function GoogleButton() {
  return (
    <button className={fastSignInButton}>
        <Image src={GoogleIcon} alt='GoogleIcon'/>
        <p>Google</p>
    </button>
  )
}
