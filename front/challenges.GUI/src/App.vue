<template>
      <nav class="navbar navbar-expand-sm navbar-light bg-light">

        <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
          <li class="nav-item">
            <RouterLink class="nav-link" to="/">Umsiting</RouterLink>
          </li>
          <li class="nav-item">
            <RouterLink class="nav-link" to="/run">Royn uppgávur</RouterLink>
          </li>
        </ul>

    </nav>

    <RouterView />
  
</template>

<script setup>
    import { RouterLink, RouterView } from "vue-router";
   
</script>

<style scoped>
header {
  line-height: 1.5;
  max-height: 100vh;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }


}
</style>
