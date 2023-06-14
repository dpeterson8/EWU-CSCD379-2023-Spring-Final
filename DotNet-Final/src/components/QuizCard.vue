<template>
  <v-card v-if="isActive">
    <QuestionCard :questionId="props.questionId" @submitQuestion="updateScore"></QuestionCard>

    <v-card-actions>
      <h2>{{ totalScore }}</h2>
      <v-btn @click="">Previous</v-btn>
      <v-btn @click="curIndex++">Next</v-btn>
    </v-card-actions>
  </v-card>
  <v-card v-if="!isActive">
    <h2>Quiz Submitted</h2>
  </v-card>
</template>

<script lang="ts" setup>
import QuestionCard from '../components/QuestionCard.vue'
import { reactive, ref } from 'vue'
import type { TestQuestion } from '../scripts/testQuestion'


var curIndex = ref(1)
const questions = ref<TestQuestion[]>([])
const totalScore = ref(0)
const isActive = ref(true)

const props = defineProps<{
  questionId: number
}>()

function updateScore(score: boolean, active: boolean) {
  if(score) {
    totalScore.value++
  }

  if(active) {
    isActive.value = false
    console.log("Quiz over")
  }
}

</script>
