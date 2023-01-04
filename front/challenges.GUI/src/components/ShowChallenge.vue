<template >
    <div class="container">
        <div class="border challenge" v-if="challengeStore.editMode">
           
                <div class="mb-3">
                    <label for="orderInSequence" class="form-label">Nummar</label>
                    <input v-model="challengeStore.activeChallenge.orderInSequence" required type="text" class="form-control" id="orderInSequence" aria-describedby="orderInSequenceHelp">
                    <div id="orderInSequenceHelp" class="form-text">Nær hendan uppgávan kemur í røðini</div>
                </div>
                <div class="mb-3">
                    <label for="challengeName" class="form-label">Navn</label>
                    <input v-model="challengeStore.activeChallenge.name" required type="text" class="form-control" id="challengeName" >
                    
                </div>
                <div class="mb-3">
                    <label for="challengeQuestion" class="form-label">Spurningur</label>
                    <input v-model="challengeStore.activeChallenge.question" type="text" class="form-control" id="challengeQuestion" >
                   
                </div>
                <div class="mb-3">
                    <label for="challengeText" class="form-label">Tekstur</label>
                    <input v-model="challengeStore.activeChallenge.text" type="text" class="form-control" id="challengeText" >
                   
                </div>
                <ShowOptions></ShowOptions>
                <button class="btn btn-success" @click="saveChallenge(challengeStore.activeChallenge)"><i class="bi bi-cloud-plus"></i> Goym</button>
                <button class="btn btn-danger float-end" @click="deleteChallenge(challengeStore.activeChallenge)"><i class="bi bi-x-circle"></i> Strika</button>
                    
       
        </div>
        <div v-else class="border challenge">
            <h5 class="challengeName">{{ challengeStore.activeChallenge.name }}</h5>
            <h2 class="challengeText">{{ challengeStore.activeChallenge.text }}</h2>
            <h5 class="challengeQuestion">{{ challengeStore.activeChallenge.question }}</h5>
            <br/><br/>
            <ShowOptions></ShowOptions>
        </div>
    </div>
</template>

<script setup>
    import ShowOptions from './ShowOptions.vue';
    import { useChallengeStore } from "@/stores/challenge";

    const challengeStore = useChallengeStore();

    const saveChallenge = (challenge) => {
        console.log(challenge);
        challengeStore.saveChallenge(challenge);
        challengeStore.editMode = false;
    };

    const deleteChallenge = (challenge) => {
        challengeStore.deleteChallenge(challenge);
    }
</script>
<style scoped>
    .challenge{
        width: 100%;
        margin: 0 auto;
        padding: 15px;
    }

    .challengeName {
        text-align: left;
    }

    .challengeText{
        text-align: center;
        margin-top: 45px;
        margin-bottom: 5px;
    }

    .challengeQuestion{
        text-align: right;
    }
</style>