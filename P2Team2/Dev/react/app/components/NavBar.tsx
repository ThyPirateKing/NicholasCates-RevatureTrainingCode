'use client'

//import Head from "next/head";
import HeaderStyle from "../styles/HeaderStyle.module.css";
import Link from 'next/link';

export const NavBar = () => {
    return(
            <nav id={HeaderStyle.header}>
                <button className={HeaderStyle.navButton}><Link href='/'>Home</Link></button>
                <button className={HeaderStyle.navButton}><Link href='/pages/characterDisplay'>Display Characters</Link></button>
                <button className={HeaderStyle.navButton}><Link href='/pages/characterForm'>Create New Character</Link></button>
                <button className={HeaderStyle.shopButton}>$ SHOP $</button>
            </nav>
    )
}