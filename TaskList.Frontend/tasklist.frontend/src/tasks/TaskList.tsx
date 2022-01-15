import React, { FC, ReactElement, useRef, useEffect, useState } from 'react';
import { CreateTaskDto, Client, TaskLookupDto } from '../api/api';
import { FormControl } from 'react-bootstrap';

const apiClient = new Client('https://localhost:7250');

async function createTask(task: CreateTaskDto) {
    await apiClient.create('1.0', task);
    console.log('Task is created.');
}

const TaskList: FC<{}> = (): ReactElement => {
    let textInput = useRef(null);
    const [tasks, setTasks] = useState<TaskLookupDto[] | undefined>(undefined);

    async function getTasks() {
        const taskListVm = await apiClient.getAll('1.0');
        setTasks(taskListVm.tasks);
    }

    useEffect(() => {
        setTimeout(getTasks, 500);
    }, []);

    const handleKeyPress = (event: React.KeyboardEvent<HTMLInputElement>) => {
        if (event.key === 'Enter') {
            const task: CreateTaskDto = {
                title: event.currentTarget.value,
            };
            createTask(task);
            event.currentTarget.value = '';
            setTimeout(getTasks, 500);
        }
    };

    return (
        <div>
            Tasks
            <div>
                <FormControl ref={textInput} onKeyPress={handleKeyPress} />
            </div>
            <section>
                {tasks?.map((task) => (
                    <div>{task.title}</div>
                ))}
            </section>
        </div>
    );
};
export default TaskList;