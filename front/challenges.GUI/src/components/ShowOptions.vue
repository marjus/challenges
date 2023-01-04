<template>  
    <div class="row row-cols-2">
        <div class="col" v-for="option in challengeStore.activeChallenge.options" :key="option.id">  
            <div class="form-group" @click="selectOption(option)" v-if="challengeStore.editMode">
                <div class="alert alert-dismissible border option" :class="{ 'alert-success': option.isCorrect, 'alert-light': !option.isCorrect  }">
                    <input class="form-control" title="Valmøguleiki" required placeholder="Valmøguleiki" v-model="option.content">
                </div>
            </div>
            <div v-else>
                <div  class="alert alert-dismissible border option" :class="{ 'alert-success': option.isCorrect, 'alert-light': !option.isCorrect  }">
                    <h4>
                        {{ option.content }}
                    </h4>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
    import { useChallengeStore } from "@/stores/challenge";

    const challengeStore = useChallengeStore();

    const selectOption = (o) => {  challengeStore.setCorrectOption(o) };  

</script>

<style scoped>
    .options{
        width: 100%;
    }
    .option{
        text-align: center;
    }
    
</style>