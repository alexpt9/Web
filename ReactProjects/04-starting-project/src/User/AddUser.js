import React from "react";
import styles from "./AddUser.module.css"


const AddUser = (props) => {
    return (<form>
        <div className={styles.input}>
            <label>Name</input>
            <input
            type="text"/>
        </div>
    </form>);
}