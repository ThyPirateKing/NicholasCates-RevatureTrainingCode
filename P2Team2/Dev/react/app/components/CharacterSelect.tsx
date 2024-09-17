import BodyStyle from "../styles/BodyStyle.module.css";

export const CharacterSelect = () => {
    return(
        <div id={BodyStyle.column}>
            <select required id="characters" name="characters">
                <option value="" selected disabled hidden>Select Character</option>
                <option value="Merlin">Merlin</option>
                <option value="Arthur">Arthur</option>
            </select>
            <ul>
                <li>Level: </li>
                <li>Exp: </li>
                <li>Class: </li>
                <li>HP: currentHP/maxHP</li>
                <li>AC: </li>
                <li>Gold: </li>
                <li>Str: </li>
                <li>Dex: </li>
                <li>Wis: </li>
                <li>Magic: </li>
                <li>Magic Resist: </li>
            </ul>
            <button>Delete Character</button>
        </div>
    )
}