'use client'
import Image from "next/image";
import HeaderStyle from "./styles/HeaderStyle.module.css";
import BodyStyle from "./styles/BodyStyle.module.css";
import Link from 'next/link';
import { NavBar } from "./components/NavBar";
import { CharacterSelect } from "./components/CharacterSelect";

export default function Home() {
  return (
    <main id="Home">
      <NavBar/>
      <h1 className={HeaderStyle.h1}>Welcome to Character Creator!</h1>
      <div id={BodyStyle.home}>
        <p>Select one of the options above to get started.</p>
      </div>
    </main>
  );
}