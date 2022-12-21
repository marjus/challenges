// stores/users.js
import { defineStore } from 'pinia'
// Import axios to make HTTP requests
import axios from "axios"

export const useChallengeStore = defineStore("challenge",{
    state: () => ({
        challenges: [],
    }),
    getters: {
        getChallenges(state){
            return state.challenges
          }
    },
    actions: {
        async fetchChallenges() {
            try {
              const data = await axios.get('https://learnchallengetest1.azurewebsites.net/Challenges/GetChallengeList')
                this.challenges = data.data
              }
              catch (error) {
                alert(error)
                console.log(error)
            }
        }
    },
})