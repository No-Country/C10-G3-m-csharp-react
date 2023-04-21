import React from 'react';
import Image from 'next/image';
import GoogleIcon from '../../../public/img/buttons/google.png';
import styles from '../../scss/components/barrel_components.module.scss';


const {fastSignInButton, imgStyled} = styles;

export default function GoogleButton() {
  return (
    <button className={fastSignInButton}>
        <Image src={GoogleIcon} alt='GoogleIcon' className={imgStyled}/>
        <p>Google</p>
    </button>
  )
}
