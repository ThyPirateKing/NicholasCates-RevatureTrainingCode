'use client'

import React, { useState } from "react";
import { NavBar } from "../../components/NavBar";
import BodyStyle from "../../styles/BodyStyle.module.css";


export default function CharacterForm() {
    const [characterName, setCharacterName] = useState('');

    return(
        <main id="CharacterForm">
            <NavBar/>
            <header className={BodyStyle.header}>Create Your Character!</header>
            <form id={BodyStyle.body}>
                <label>Character Name: <input type="text" value={characterName} onChange={(e) => setCharacterName(e.target.value)}/></label>
                <p>Current Name: {characterName}</p>
            </form>
        </main>
    )
}