<template>
    <h1>Uppgávur</h1>
    <div class="row">
        <div class="col">
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
                <tr>
                    <td>
                        {{ challenge.OrderInSequence }}
                    </td>
                    <td>
                        {{ challenge.Name }}
                    </td>
                    <td>
                        {{ challenge.Question }}
                    </td>
                    <td>
                        {{ challenge.Text }}
                    </td>
                    <td>
                        <button class="btn btn-link" @click="displayChallenge(challenge)">
                            <i class="bi bi-zoom-in"></i> Vís
                        </button>
                        <button class="btn btn-link" @click="editChallenge(challenge)"> 
                            <i class="fa fa-utensils"></i> Broyt
                        </button>
                        <button class="btn btn-link">Strika</button>
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

    onMounted(() => {
        challengeStore.fetchChallenges();
    });

</script>