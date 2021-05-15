import { ITeacher } from './teacher.interface';

export interface ILesson {
   lesson_id: number;
   group_id: number;
   day_number: string;
   day_name: string;
   lesson_name: string;
   lesson_full_name: string;
   lesson_number: string;
   lesson_room: string;
   lesson_type: string;
   teacher_name: string;
   lesson_week: string;
   time_start: string;
   time_end: string;
   lesson_date: Date;
   Teachers: ITeacher[];
}
