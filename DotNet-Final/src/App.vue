<template>
  <v-app>
    <span class="bg"></span>
    <v-app-bar :elevation="3">
      <template v-slot>
        <v-app-bar-title>
          <RouterLink to="/">
            <v-icon icon="mdi-alpha-w-box" color="orange-darken-3"></v-icon>
            Wordle
          </RouterLink>
        </v-app-bar-title>
        <v-spacer></v-spacer>

        <v-btn icon="mdi-brightness-7" @click="switchTheme"></v-btn>

        <SignInCard v-if="!signInService.isSignedIn"></SignInCard>
        <v-btn v-if="signInService.isSignedIn" @click="signInService.signOut()">Sign-Out</v-btn>

        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn icon="mdi-hamburger" v-bind="props"></v-btn>
          </template>

          <v-list width="200">
            <v-list-item>
              <v-list-item-title>
                <RouterLink :to="{ name: 'home' }"> Home </RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title>
                <RouterLink :to="{ name: 'about' }"> About </RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title>
                <RouterLink :to="{ name: 'quiz' }"> Quiz </RouterLink>
              </v-list-item-title>
            </v-list-item>
            <v-list-item>
              <v-list-item-title v-if="signInService.isSignedIn" @click="signInService.signOut()">
                Sign-out
              </v-list-item-title>
              <v-list-item-title v-if="!signInService.isSignedIn" @click="signIn">
                Sign-in
              </v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </template>
    </v-app-bar>

    <v-main>
      <RouterView />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { reactive, ref } from 'vue'
import { useDisplay } from 'vuetify'
import { provide } from 'vue'
import { Services } from './scripts/services'
import ActiveUser from './components/ActiveUser.vue'
import { inject } from 'vue'
import type { SignInService } from './scripts/signInService'
import SignInCard from './components/SignInCard.vue'

// Provide the useDisplay to other components so that it can be used in testing.
const display = reactive(useDisplay())
provide(Services.Display, display)

// const playerService = new PlayerService()
// playerService.setupPlayerAsync()
// provide(Services.PlayerService, playerService)

const signInService = inject(Services.SignInService) as SignInService
const showSignIn = ref(false)

const theme = useTheme()

function switchTheme() {
  if (theme.global.name.value === 'light') {
    setDarkTheme()
  } else {
    setLightTheme()
  }
}

function setLightTheme() {
  theme.global.name.value = 'light'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

function signIn() {
  showSignIn.value = true
}

// setTimeout(() => {
//   signInService.signInAsync('Admin@wordle.com', 'P@ssw0rd123')
// }, 1000)
</script>
