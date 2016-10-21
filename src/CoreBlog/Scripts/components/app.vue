<template>
<div>
    <h2>vue!</h2>
    {{ hello() }}
</div>
</template>

<script>
export default {
    methods: {
      hello(): string { return "Hello Vue.js!" }
    }
}
</script>
