<template>
    <div class="row">
        <div class="col">
        <h1 class="float-start">Uppgávur</h1></div><div class="col">
        <button @click="newChallenge()" class="btn btn-success float-end"><i class="bi bi-plus-circle-dotted"></i> Nýggja uppgávu</button>
    </div>
    </div>
    <div class="row">
        <div class="col-8">
        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Nummar</th>
                    <th>Navn</th>
                    <th>Spurningur</th>
                    <th>Tekstur</th>
                    <th></th>
                </tr>
            </thead>
            <tbody v-for="(challenge, index) in challengeStore.challenges" :key="index">
                <tr @click="displayChallenge(challenge)">
                    <td>
                        {{ challenge.orderInSequence }}
                    </td>
                    <td>
                        {{ challenge.name }}
                    </td>
                    <td>
                        {{ challenge.question }}
                    </td>
                    <td>
                        {{ challenge.text }}
                    </td>
                    <td nowrap>
                        <button class="btn btn-link" @click.stop="editChallenge(challenge)"> 
                            <i class="bi bi-pencil"></i> Broyt
                        </button>
                        <button class="btn btn-link" @click.stop="deleteChallenge(challenge)"><i class="bi bi-x-circle"></i> Strika</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="col">
        <ShowChallenge></ShowChallenge>
    </div>
    </div>
</template>

<script setup>
    import { ref, onMounted, computed } from "vue";
    import { useChallengeStore } from "@/stores/challenge";
import ShowChallenge from "./ShowChallenge.vue";

    const challengeStore = useChallengeStore();

    const displayChallenge = (challenge) => {
        challengeStore.setActive(challenge);
        challengeStore.editMode = false;
        
    };

    const editChallenge = (challenge) => {
        challengeStore.setActive(challenge);
        challengeStore.editMode = true;
        
    };

    const newChallenge = () => {
        challengeStore.newEmpty();
    }

    const deleteChallenge = (challenge) => {
        challengeStore.deleteChallenge(challenge);
    }

    onMounted(() => {
        challengeStore.fetchChallenges();
        challengeStore.loadRandom();
        challengeStore.runMode = false;
    });

</script>