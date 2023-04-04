import React from 'react';
import Image from 'next/image';
import AppleIcon from '../../../public/img/buttons/apple.png';
import styles from '../../scss/components/barrel_components.module.scss';


const {fastSignInButton,imgStyled} = styles;

export default function AppleButton() {
  return (
    <button className={fastSignInButton}>
        <Image src={AppleIcon} alt='GoogleIcon' className={imgStyled}/>
        <p>Apple</p>
    </button>
  )
}
