import React from "react";
import { NavBar } from "@/app/components/NavBar";
import { CharacterSelect } from "@/app/components/CharacterSelect";
import HeaderStyle from "../../styles/HeaderStyle.module.css";
import BodyStyle from "../../styles/BodyStyle.module.css";

const CharacterDisplay = () => {
    return(
        <main id="CharacterDisplay">
            <NavBar/>
            <h1 className={HeaderStyle.h1}>Character Display</h1>
            <div className={BodyStyle.container}>
                <div id={BodyStyle.column}>
                    <CharacterSelect/>
                </div>
                <div id={BodyStyle.column}>
                    <img src="" alt="img not found"></img>
                </div>
            </div>
        </main>
    )
}

export default CharacterDisplay;