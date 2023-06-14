<template>
  <div>
    <v-alert v-model="props.alert" type="error" color="red" title="Error">
      {{ props.info }}
    </v-alert>
  </div>
</template>

<script setup lang="ts">
const props = defineProps<{
  alert: boolean
  info: string
}>()
</script>
