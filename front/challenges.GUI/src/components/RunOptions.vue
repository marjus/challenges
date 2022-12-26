<template>  

    <div class="row row-cols-2">
        <div class="col" v-for="option in challengeStore.activeChallenge.Options" :key="option.id">  
            <div>
                <RunOption :option="option" :isCorrect="option.IsCorrect"></RunOption>
            </div>
        </div>
    </div>

</template>

<script setup>
    
    import  RunOption from "./RunOption.vue";
    import { useChallengeStore } from "@/stores/challenge";

    const challengeStore = useChallengeStore();

    const selectOption = (option) => {  
        challengeStore.setCorrectOption(option) 
    };  

    const optionClicked = (option) => { 
        // isCorrect = option.isCorrect;
        // isFalse = option.isFalse;
        // if (option.IsCorrect)
        //     alert("correct");
        // else
        //     alert("incorrect");
    }; 

    const classCorrect = {
      'alert-success': false,
      'alert-danger': false
    }
    
</script>



<style scoped>
    .options{
        width: 100%;
    }
    /* .option{
        margin: 10px; 
    }
    */
</style>