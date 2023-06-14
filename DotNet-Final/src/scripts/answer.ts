export class Answer {
  answer: string | null
  guessed = false

  constructor(answer?: string | null, guess?: string | null) {
    if (answer) {
      this.answer = answer
    } else {
      this.answer = null
    }
  }

  get getAnswer() {
    return this.answer
  }

  get result() {
    return this.guessed
  }

  public submit() {
    this.guessed = true
  }
}
