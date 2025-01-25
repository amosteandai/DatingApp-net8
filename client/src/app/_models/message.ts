export interface Message {
  id: number
  senderId: number
  senderUsername: string
  senderPhotoUrl: string
  recipientId: number
  recipientPhotoUrl: string
  recipientUsrname: string
  content: string
  dateRead?: Date
  messageSent: Date
}