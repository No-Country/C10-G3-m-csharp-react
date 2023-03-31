import React from 'react';
import Image from 'next/image';
import AppleIcon from '../../../public/apple.png';
import styles from '../../scss/components/barrel_components.module.scss';


const {fastSignInButton} = styles;

export default function AppleButton() {
  return (
    <button className={fastSignInButton}>
        <Image src={AppleIcon} alt='GoogleIcon'/>
        <p>Apple</p>
    </button>
  )
}
