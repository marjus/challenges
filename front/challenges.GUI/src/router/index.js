import { createRouter, createWebHistory } from "vue-router";

import ChallengeList from "@/components/ChallengeList.vue";
import RunChallenge from "@/components/RunChallenge.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/challenges",
      name: "challenges",
      component: ChallengeList,
    },
    {
      path: "/run",
      name: "run",
      component: RunChallenge,
    },
  ],
});

export default router;
