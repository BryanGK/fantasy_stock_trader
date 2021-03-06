import React from 'react';
import { Chart } from 'react-google-charts';

function SummaryChart({ processedHoldings }) {

    return (
        <div className="summary-chart">
            <Chart
                width={'500px'}
                height={'300px'}
                chartType="PieChart"
                loader={<div>Loading Chart</div>}
                data={processedHoldings}
                options={{
                    title: 'Current Holdings',
                    is3D: true,
                }}
                rootProps={{ 'data-testid': '2' }}
            />
        </div>
    )
}

export default SummaryChart;