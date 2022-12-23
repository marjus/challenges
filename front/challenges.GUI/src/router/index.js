import { createRouter, createWebHistory } from "vue-router";

import ChallengeList from "@/components/ChallengeList.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/challenges",
      name: "challenges",
      component: ChallengeList,
    },
  ],
});

export default router;
