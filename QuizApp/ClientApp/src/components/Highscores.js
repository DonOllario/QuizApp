import React, { Component } from 'react';
import { Frontpage_logo } from './Frontpage_logo';
import './Highscores.css'

export class Highscores extends Component {
  static displayName = Highscores.name;

    openCategory(evt, category) {
        // Declare all variables
        var i, tabcontent, tablinks;

        // Get all elements with class="tabcontent" and hide them
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }

        // Get all elements with class="tablinks" and remove the class "active"
        tablinks = document.getElementsByClassName("tablinks");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" active", "");
        }

        // Show the current tab, and add an "active" class to the button that opened the tab
        document.getElementById(category).style.display = "block";
        evt.currentTarget.className += " active";
    }

  render () {
    return (
        <div>
            <Frontpage_logo />

            <div class="tab">
                {<a href="javascript:void(0)" onClick={(event) => this.openCategory(event, 'Highscores')}> <button class="tablinks">Highscores</button> </a>}
                {<a href="javascript:void(0)" onClick={(event) => this.openCategory(event, 'Science')}> <button class="tablinks">Science</button> </a>}
                {<a href="javascript:void(0)" onClick={(event) => this.openCategory(event, 'Art')}> <button class="tablinks">Art</button> </a>}
            </div>

            <div id="Highscores" class="tabcontent">
                <h2>Top 10</h2>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
            </div>

            <div id="Science" class="tabcontent">
                <h2>Science highscores</h2>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
            </div>

            <div id="Art" class="tabcontent">
                <h2>Art Highscores</h2>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
                <p>User - Score</p>
            </div>

            <br /> <br /> <br />
        </div>
    );
  }
}
